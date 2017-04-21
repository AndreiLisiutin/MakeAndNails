const gulp = require('gulp');
const ts = require('gulp-typescript');
const sourcemaps = require('gulp-sourcemaps');
const debug = require('gulp-debug');
const gulpIf = require('gulp-if');
const del = require('del');
const newer = require('gulp-newer');
const sass = require('gulp-sass');
var merge = require('merge-stream');
var rename = require('gulp-rename');

var tsProject = ts.createProject('tsconfig.json');
var isDevelopment = !process.env.NODE_ENV || process.env.NODE_ENV == 'development';

var paths = {
	src: {
		root: "./Assets"
	},
	dest: {
		root: "./wwwroot"
	}
};
paths.src.scripts = paths.src.root + "/Scripts";
paths.src.js = paths.src.scripts + "/app";
paths.src.lib = "./node_modules";
paths.src.bootstrap = paths.src.lib + "/bootstrap-sass";
paths.src.bootstrapStyles = paths.src.bootstrap + "/assets/stylesheets";
paths.src.bootstrapFonts = paths.src.bootstrap + "/assets/fonts";
paths.src.styles = paths.src.root + "/Styles";
paths.src.images = paths.src.root + "/Images";
paths.dest.scripts = paths.dest.root + "/Scripts";
paths.dest.js = paths.dest.scripts + "/app";
paths.dest.lib = paths.dest.scripts + "/lib";
paths.dest.styles = paths.dest.root + "/Styles";
paths.dest.images = paths.dest.root + "/Images";

// Билд
gulp.task('ts:compile:copy', function () {
	return tsProject.src(paths.src.js + "/**/*.ts", { since: gulp.lastRun('ts:compile:copy') })
		.pipe(newer({ dest: paths.dest.js, ext: '.js' }))
		.pipe(gulpIf(isDevelopment, debug({ title: 'ts from assets' })))
		.pipe(sourcemaps.init())
		.pipe(tsProject()).js
		.pipe(sourcemaps.write())
		.pipe(gulp.dest(paths.dest.js));
});
gulp.task('lib:copy', function () {
	return gulp.src([
		paths.src.lib + '/core-js/client/shim.min.js',
		paths.src.lib + '/systemjs/dist/system-polyfills.js',
		paths.src.lib + '/systemjs/dist/system.src.js',
		paths.src.lib + '/reflect-metadata/Reflect.js',
		paths.src.lib + '/rxjs/**',
		paths.src.lib + '/zone.js/dist/**',
		paths.src.lib + '/@angular/**',
		paths.src.lib + '/angular2-jwt/**',
		paths.src.lib + '/ng2-validation/**',
		paths.src.lib + '/libphonenumber-js/**',
	], { since: gulp.lastRun('lib:copy'), base: paths.src.lib })
		.pipe(newer(paths.dest.lib))
		.pipe(gulp.dest(paths.dest.lib));
});
gulp.task('bootstrap:compile:copy', function () {
	var fontsStream = gulp
        .src(paths.src.bootstrapFonts + '/**/*')
		.pipe(newer(paths.dest.styles))
		.pipe(gulpIf(isDevelopment, debug({ title: 'fonts from bootstrap' })))
        .pipe(gulp.dest(paths.dest.styles));

	var bootstrapStream = gulp
		.src(paths.src.styles + '/bootstrap-customized.scss')
		.pipe(newer(paths.dest.styles + '/bootstrap.css'))
		.pipe(gulpIf(isDevelopment, debug({ title: 'bootstrap from bootstrap' })))
		.pipe(sass({
			outputStyle: 'nested',
			precison: 3,
			errLogToConsole: true,
			includePaths: [paths.src.bootstrapStyles]
		}))
		.pipe(rename('bootstrap.css'))
		.pipe(gulp.dest(paths.dest.styles));
	return merge(fontsStream, bootstrapStream);
});
gulp.task('images:copy', function () {
	return gulp.src(paths.src.images + '/**/*.*', { since: gulp.lastRun('images:copy') })
		.pipe(newer(paths.dest.images))
		.pipe(gulpIf(isDevelopment, debug({ title: 'images from assets' })))
		.pipe(gulp.dest(paths.dest.images));
});
gulp.task('styles:copy', function () {
	return gulp.src(paths.src.js + '/**/*.css', { since: gulp.lastRun('styles:copy') })
		.pipe(newer(paths.dest.js))
		.pipe(gulpIf(isDevelopment, debug({ title: 'styles from assets' })))
		.pipe(gulp.dest(paths.dest.js));
});
gulp.task('views:copy', function () {
	return gulp.src(paths.src.js + '/**/*.html', { since: gulp.lastRun('views:copy') })
		.pipe(newer(paths.dest.js))
		.pipe(gulpIf(isDevelopment, debug({ title: 'views from assets' })))
		.pipe(gulp.dest(paths.dest.js));
});
gulp.task('settings:copy', function () {
	return gulp.src(paths.src.root + '/*.{html,config.js}', { since: gulp.lastRun('settings:copy') })
		.pipe(newer(paths.dest.root))
		.pipe(gulpIf(isDevelopment, debug({ title: 'settings from assets' })))
		.pipe(gulp.dest(paths.dest.root));
});

// Очистка
gulp.task('js:clean', function () {
	return del(paths.dest.js);
});
gulp.task('lib:clean', function () {
	return del(paths.dest.lib);
});
gulp.task('styles:clean', function () {
	return del(paths.dest.styles);
});
gulp.task('images:clean', function () {
	return del(paths.dest.images);
});
gulp.task('settings:clean', function () {
	return del(paths.dest.root + '/*.{html,config.js}');
});
gulp.task('assets:clean', gulp.parallel('js:clean', 'styles:clean', 'images:clean', 'settings:clean'));

// Почистить и построить все, кроме библиотек
gulp.task('assets:build',
	gulp.series(
		gulp.parallel('js:clean', 'styles:clean', 'images:clean', 'settings:clean'),
		gulp.parallel('ts:compile:copy', 'bootstrap:compile:copy', 'images:copy', 'styles:copy', 'views:copy', 'settings:copy')
	)
);
// Почистить и построить библиотеки
gulp.task('assets:lib:build', gulp.series('lib:clean', 'lib:copy'));

// Следить за всеми изменениями, кроме библиотек
gulp.task('assets:watch', function () {
	gulp.watch(paths.src.js + "/**/*.ts", gulp.series('ts:compile:copy'));
	gulp.watch(paths.src.js + "/**/*.html", gulp.series('views:copy'));
	gulp.watch(paths.src.js + '/**/*.css', gulp.series('styles:copy'));
	gulp.watch(paths.src.images + '/**/*.*', gulp.series('images:copy'));
	gulp.watch(paths.src.styles + '/bootstrap-customized.scss', gulp.series('bootstrap:compile:copy'));
	gulp.watch(paths.src.root + '/*.{html,config.js}', gulp.series('settings:copy'));
});

// Почистить и построить все, кроме библиотек + следить за всеми изменениями, кроме библиотек
gulp.task('dev', gulp.series('assets:build', 'assets:watch'))