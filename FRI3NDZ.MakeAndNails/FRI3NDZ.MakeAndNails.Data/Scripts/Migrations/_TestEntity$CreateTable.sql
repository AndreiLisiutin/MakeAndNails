-- Процедура создания тестовой сущности в БД.
CREATE OR REPLACE FUNCTION _TestEntity$CreateTable() RETURNS VOID AS 
$$
	BEGIN
		CREATE TABLE IF NOT EXISTS public._test_entity
		(
			_test_entity_id SERIAL,
			name TEXT NOT NULL,
			date TIMESTAMP WITH TIME ZONE NOT NULL,
			CONSTRAINT _test_entity_pkey PRIMARY KEY (_test_entity_id)
		);
	END;
$$ 
LANGUAGE plpgsql VOLATILE;
