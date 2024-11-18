CREATE VIEW [dbo].[v_MostPopularMenuItems]
AS
SELECT 
    [P].[NAME] AS [ProductName],
    COUNT([B].[PRODUCT_ID]) AS [TimesOrdered]
FROM 
    [dbo].[CART] AS [B]
INNER JOIN 
    [dbo].[PRODUCT] AS [P] ON [B].[PRODUCT_ID] = [P].[ID]
GROUP BY 
    [P].[NAME]






