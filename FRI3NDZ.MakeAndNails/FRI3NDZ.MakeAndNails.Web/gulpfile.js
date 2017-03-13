var gulp = require('gulp');
var ts = require('gulp-typescript');
var sourcemaps = require('gulp-sourcemaps');

var paths = {};
paths.srcRoot = "./Assets";
paths.destRoot = "./wwwroot";

gulp.task('npm:copy', function () {
    gulp.src([
        './node_modules/**/*.js'
    ])
    .pipe(gulp.dest(paths.destRoot + "/Scripts/lib"));
});
gulp.task('settings:copy', function () {
    gulp.src([
        paths.srcRoot + '/index.html',
        paths.srcRoot + '/systemjs.config.js'
    ])
    .pipe(gulp.dest(paths.destRoot));
});
gulp.task('images:copy', function () {
    gulp.src([
        paths.srcRoot + '/Images/**/*.*'
    ])
    .pipe(gulp.dest(paths.destRoot + '/Images'));
});
gulp.task('styles:copy', function () {
    gulp.src([
        paths.srcRoot + '/Styles/**/*.css'
    ])
    .pipe(gulp.dest(paths.destRoot + '/Styles'));
});
gulp.task('views:copy', function () {
    gulp.src([
        paths.srcRoot + '/Views/**/*.*'
    ])
    .pipe(gulp.dest(paths.destRoot + '/Views'));
});

var tsProject = ts.createProject('tsconfig.json');
gulp.task('ts:compile:copy', function () {
    gulp.src([
        paths.srcRoot + "/Scripts/app/**/*.ts"
    ])
    .pipe(sourcemaps.init())
    .pipe(tsProject()).js
    .pipe(sourcemaps.write())
    .pipe(gulp.dest(paths.destRoot + "/Scripts/app/"));
});

gulp.task('assets:watch', ['ts:compile:copy', 'images:copy', 'styles:copy', 'views:copy'], function () {
    gulp.watch(paths.srcRoot + "/Scripts/app/**/*.ts", ['ts:compile:copy']);
    gulp.watch(paths.srcRoot + '/Styles/**/*.css', ['styles:copy']);
    gulp.watch(paths.srcRoot + '/Images/**/*.*', ['images:copy']);
    gulp.watch(paths.srcRoot + '/Views/**/*.*', ['views:copy']);
});