IF NOT EXISTS (SELECT * FROM sys.change_tracking_databases WHERE database_id = DB_ID(N'taixin_pop')) 
   ALTER DATABASE [taixin_pop] 
   SET  CHANGE_TRACKING = ON
GO
