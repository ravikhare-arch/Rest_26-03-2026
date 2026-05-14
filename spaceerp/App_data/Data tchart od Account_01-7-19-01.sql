IF @Type = 'GSTMonthDet' and @cond = '' 
SELECT substring([Invoice Date],5,2) as sMonth ,substring([Invoice Date],1,4) as sYear,sum(TotGst) As totTax from vw_gst
where  [Invoice Date] between @sFirstName and @sLastName  
group by substring([Invoice Date],5,2),substring([Invoice Date],1,4)


IF @Type = 'ProfitLossMonthyIncomeCategoryTot' and @cond = '' 
SELECT sMonth,sYear, sum([Credit Amount]) as sIncome
from (
SELECT [sMainAccountTitle] ,[sSubAccount],[nChartOfAccountID]
	,[Account Code],[Account Title] ,[Debit Amount]
	,[Credit Amount] ,[Description] ,[Voucher No]
	,[Voucher Date] ,[Voucher Type],mvouchertype.sVoucherType ,[sPostedby]
	, substring([Voucher Date],5,2) as sMonth, substring([Voucher Date],1,4) as sYear
FROM [dbo].[vw_profitloss]
inner join mvouchertype on [vw_profitloss].[Voucher Type]=mvouchertype.nVoucherTypeID
) d 
inner join mmonth on d.sMonth=mmonth.nMonthID
where [Credit Amount]>0 and [Voucher Date] between @sFirstName and @sLastName
group by sMonth,sYear


IF @Type = 'ProfitLossMonthyExpCategoryTot' and @cond = '' 
SELECT sMonth,sYear, sum([Debit Amount]) as sExpense
from (
SELECT [sMainAccountTitle] ,[sSubAccount],[nChartOfAccountID]
	,[Account Code],[Account Title] ,[Debit Amount]
	,[Credit Amount] ,[Description] ,[Voucher No]
	,[Voucher Date] ,[Voucher Type],mvouchertype.sVoucherType ,[sPostedby]
	, substring([Voucher Date],5,2) as sMonth, substring([Voucher Date],1,4) as sYear
FROM [dbo].[vw_profitloss]
inner join mvouchertype on [vw_profitloss].[Voucher Type]=mvouchertype.nVoucherTypeID
) d 
inner join mmonth on d.sMonth=mmonth.nMonthID
where [Debit Amount]>0 and [Voucher Date] between @sFirstName and @sLastName
group by sMonth,sYear