IF EXISTS (SELECT * FROM sys.change_tracking_tables WHERE object_id = OBJECT_ID(N'[dbo].[pf_bookmark]')) 
   ALTER TABLE [dbo].[pf_bookmark] 
   DISABLE  CHANGE_TRACKING
GO
