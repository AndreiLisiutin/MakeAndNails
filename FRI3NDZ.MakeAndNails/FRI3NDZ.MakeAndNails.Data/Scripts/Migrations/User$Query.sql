-- Выборка пользователей.
CREATE OR REPLACE FUNCTION User$Query(
	_id INTEGER --идентификатор пользователя
	, _login TEXT --логин пользователя
	, _page_size INTEGER = 1000 --размер страницы
	, _page_number INTEGER = 0 --номер страницы
)
RETURNS TABLE (
	Id INT 
	, Name TEXT 
	, Surname TEXT 
	, Patronymic TEXT 
	, Login TEXT 
	, Email TEXT 
	, PasswordHash TEXT 
	, CreatedOn TIMESTAMP WITH TIME ZONE
	, Phone TEXT) 
AS 
$$
	BEGIN
		RETURN QUERY
		 
		SELECT u.user_id AS Id 
			, u.name AS Name 
			, u.surname AS Surname 
			, u.patronymic AS Patronymic 
			, u.login AS Login 
			, u.email AS Email 
			, u.password_hash AS PasswordHash 
			, u.created_on AS CreatedOn 
			, u.phone AS Phone 
		FROM public."user" u 
		WHERE (_id IS NULL OR u.user_id = _id) 
			AND (_login IS NULL OR u.login = _login)
		OFFSET _page_number * _page_size LIMIT _page_size;
	END;
$$ 
LANGUAGE plpgsql VOLATILE;