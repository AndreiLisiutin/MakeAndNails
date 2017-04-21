-- Процедура создания сущности пользователя в БД.
CREATE OR REPLACE FUNCTION User$CreateTable() RETURNS VOID AS 
$$
	BEGIN
		CREATE TABLE IF NOT EXISTS public."user"
		(
			user_id SERIAL,
			name TEXT NOT NULL,
			surname TEXT NOT NULL,
			patronymic TEXT,
			login TEXT NOT NULL,
			email TEXT,
			password_hash TEXT NOT NULL,
			created_on TIMESTAMP WITH TIME ZONE NOT NULL,
			phone TEXT,
			CONSTRAINT user_pkey PRIMARY KEY (user_id),
			CONSTRAINT user_login_key UNIQUE (login)
		);
	END;
$$ 
LANGUAGE plpgsql VOLATILE;
