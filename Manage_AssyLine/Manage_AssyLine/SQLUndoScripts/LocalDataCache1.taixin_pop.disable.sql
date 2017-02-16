-- This code can be used to disable change tracking within your database
-- Please ensure all tables have stopped using chagne tracking before executing this code
    
IF EXISTS (SELECT * FROM sys.change_tracking_databases WHERE database_id = DB_ID(N'taixin_pop')) 
  ALTER DATABASE [taixin_pop] 
  SET  CHANGE_TRACKING = OFF
GO
