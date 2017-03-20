-- Процедура удаления тестовой сущности из БД.
CREATE OR REPLACE FUNCTION _TestEntity$DropTable() RETURNS VOID AS 
$$
	BEGIN
		DROP TABLE IF EXISTS public._test_entity;
	END;
$$ 
LANGUAGE plpgsql VOLATILE;
