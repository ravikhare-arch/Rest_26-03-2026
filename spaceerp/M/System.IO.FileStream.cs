CREATE PROCEDURE [dbo].[SP_mtest] @nTestID as float, 
@sTest as nvarchar(300),
@sDd as nvarchar(300),
@nCreatedID as int,
 @nModifiedID as int,
@type as varchar(200),
@cond as varchar(200)
 AS BEGIN SET NOCOUNT ON;

IF @Type = 'add'
IF NOT EXISTS (SELECT * FROM mtest WHERE sTest = @sTest and bActive=1)
      begin 
INSERT INTO mtest(sTest,sDd,bActive,nCreatedID,dtCreated,nModifiedID,dtModified) VALUES( @sTest,@sDd,1,@nCreatedID,GetDate(), @nModifiedID,GetDate())
      select '1,Added Successfully'
   end
 ELSE
       select '0,' + @sTest + ' Already Exist'
IF @Type = 'edit'
 IF NOT EXISTS (SELECT * FROM mtest WHERE sTest = @sTest and nTestID != @nTestID and bActive=1)
      begin 
 Update mtest set sTest=@sTest, sDd=@sDd, nModifiedID=@nModifiedID,dtModified=GetDate() where nTestID=@nTestID
       select '1,Update Successfully'
     end
   ELSE
 select '0,' + @sTest + ' Already Exist'


IF @Type = 'Delete'
      begin 
 Delete From mtest WHERE nTestID=@nTestID
       select '1,Delete Successfully'
end

IF @Type = 'DeActive'
      begin 
 Update mtest set bActive=0,nModifiedID=@nModifiedID,dtModified=GetDate() WHERE nTestID=@nTestID
       select '1,Delete Successfully'
end

IF @Type = 'Show' and @cond = '' 
 Select * from mtest WHERE bActive=1

IF @Type = 'Show' and @cond != '' 
 Select * from mtest WHERE bActive=1 and nTestID=@cond

 END