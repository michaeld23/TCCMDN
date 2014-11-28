
/* 5. Display Person */
SELECT * FROM Person;
/* 6. Count the credentials (each person could have several credentials) */
SELECT Count(*) FROM Credential;
/* 7. Count the courts */
SELECT Count(*) FROM Court;
/*8. Insert a test reservation on court 123 */
INSERT INTO [dbo].[booking]
           ([dateCreation]
           ,[dateLastUpdate]
           ,[dateReservation]
           ,[recurrency]
           ,[beginHour]
           ,[endHour]
           ,[guestFirstname]
           ,[guestLastname]
           ,[FKCredential_Booker]
           ,[FKCredential_Guest]
           ,[FKGroup]
           ,[FKCourt]
           ,[statusPayment])
     VALUES
           ('2014-11-24 16:00:33'
           ,'2014-11-24 16:00:33'
           ,'2014-11-24 16:00:33'
           ,0
           ,16
           ,17
           ,NULL
           ,NULL
           ,100
           ,NULL
           ,NULL
           ,123
           ,'0')
GO

/*9. Insert a test reservation on court 1 */
INSERT INTO [dbo].[booking]
           ([dateCreation]
           ,[dateLastUpdate]
           ,[dateReservation]
           ,[recurrency]
           ,[beginHour]
           ,[endHour]
           ,[guestFirstname]
           ,[guestLastname]
           ,[FKCredential_Booker]
           ,[FKCredential_Guest]
           ,[FKGroup]
           ,[FKCourt]
           ,[statusPayment])
     VALUES
           ('2014-11-24 16:00:33'
           ,'2014-11-24 16:00:33'
           ,'2014-11-24 16:00:33'
           ,0
           ,16
           ,17
           ,NULL
           ,NULL
           ,100
           ,NULL
           ,NULL
           ,1
           ,'0')
GO

/*10. Delete court 2 if there is a booking on it */
DELETE FROM court WHERE IDCourt = 2;

/*11. Insert a member with the same login as member 23 */
INSERT INTO credential([dateCreation],[dateLastUpdate],[type],[status],[login],[password],[invitation],[validation],[FKPerson]) VALUES('2015-05-03 04:24:21','2014-08-18 23:15:19',1,0,'test22','test',0,0,15) 

/*12. Insert a member without name */
INSERT INTO person([dateCreation],[dateLastUpdate],[status],[firstname],[lastname],[address],[telephone],[email]) VALUES('2014-11-11 16:23:09','2015-10-30 11:41:48',0,'Audrey',NULL,'9168 Dignissim Rd.','07 07 41 03 34','lacus@orciluctus.net')

/*13. Insert a booking in the past */

/*14. Insert a test in the past */
INSERT INTO [dbo].[booking]
           ([dateCreation]
           ,[dateLastUpdate]
           ,[dateReservation]
           ,[recurrency]
           ,[beginHour]
           ,[endHour]
           ,[guestFirstname]
           ,[guestLastname]
           ,[FKCredential_Booker]
           ,[FKCredential_Guest]
           ,[FKGroup]
           ,[FKCourt]
           ,[statusPayment])
     VALUES
           ('2014-11-24 16:00:33'
           ,'2014-11-24 16:00:33'
           ,'2014-10-23 16:00:33'
           ,0
           ,16
           ,17
           ,NULL
           ,NULL
           ,100
           ,NULL
           ,NULL
           ,1
           ,'0')
GO

/*14. Insert a test reservation in the future */
INSERT INTO [dbo].[booking]
           ([dateCreation]
           ,[dateLastUpdate]
           ,[dateReservation]
           ,[recurrency]
           ,[beginHour]
           ,[endHour]
           ,[guestFirstname]
           ,[guestLastname]
           ,[FKCredential_Booker]
           ,[FKCredential_Guest]
           ,[FKGroup]
           ,[FKCourt]
           ,[statusPayment])
     VALUES
           ('2014-11-24 16:00:33'
           ,'2014-11-24 16:00:33'
           ,'2014-12-23 16:00:33'
           ,0
           ,16
           ,17
           ,NULL
           ,NULL
           ,100
           ,NULL
           ,NULL
           ,1
           ,'0')
GO

/*15. Insert a group */
INSERT INTO [dbo].[group]
           ([dateCreation]
           ,[dateLastUpdate]
           ,[name]
           ,[FKCredential]
           )
     VALUES
           (
		   '2014-11-24 16:00:33',
		   '2014-11-24 16:00:33',
		   'Comité',
		   '44'
		   );
GO

/*16. Delete the created group */
DELETE FROM [dbo].[group] WHERE name='Comité'
GO
