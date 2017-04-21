-- Сохранение пользователей.
CREATE OR REPLACE FUNCTION User$Save(
	_id INT --идентификатор пользователя
	, _name TEXT --имя пользователя
	, _surname TEXT --фамилия пользователя
	, _patronymic TEXT --отчество пользователя
	, _login TEXT --логин пользователя
	, _email TEXT --мыло пользователя
	, _password_hash TEXT --хэш пароля пользователя
	, _created_on TIMESTAMP WITH TIME ZONE --дата создания пользователя
	, _phone TEXT --телефон пользователя
) 
RETURNS INT
AS 
$$
	DECLARE
		new_user_id INT;
	BEGIN
	
		IF (_id > 0) THEN
			UPDATE public."user" 
			SET (name, surname, patronymic, login, email, password_hash, created_on, phone) 
			= (_name, _surname, _patronymic, _login, _email, _password_hash, _created_on, _phone) 
			WHERE user_id = _id;
			new_user_id = _id;
		ELSE
			INSERT INTO public."user" 
			(name, surname, patronymic, login, email, password_hash, created_on, phone) 
			VALUES (_name, _surname, _patronymic, _login, _email, _password_hash, _created_on, _phone)
			RETURNING user_id INTO new_user_id;
		END IF;
		
		RETURN new_user_id;
	END;
$$ 
LANGUAGE plpgsql VOLATILE;