select * from TCAD_PRODUTO where DESCRICAO like '%MANGA%'

select * from PartnerProducts

select * from TCAD_BASE_INVENTARIO where CODIGO_PRODUTOId in ( 75, 182) and forne

select a.CODIGO_FORNECEDORId, a.CODIGO_PRODUTOId, b.DESCRICAO, a.CODIGO_PRODUTO_FORNECEDOR
from TCAD_BASE_INVENTARIO a
left join TCAD_PRODUTO b
    on a.CODIGO_PRODUTOId = b.id
where b.DESCRICAO like '%MANGA%'
    and a.CODIGO_FORNECEDORId = 5

delete from TCAD_BASE_INVENTARIO where CODIGO_PRODUTOId in (181, 182) and CODIGO_FORNECEDORId = 5

-- ReceiptRepository.GetMappedReceiptProductsAsync(int receiptId)
select 
    b.[Id],
    b.[CodigoProduto] as PartnerProductId,
    b.[DescricaoProduto] as PartnerProductDescription,
    c.CODIGO_PRODUTOId as InventoryProductId
from TCAD_NOTA_FISCAL_CAPA a
join TCAD_NOTA_FISCAL_LINHA b on a.Id = b.Capa_Id
left join TCAD_BASE_INVENTARIO c 
on c.CODIGO_FORNECEDORId = a.Fornecedor_Id and c.CODIGO_PRODUTO_FORNECEDOR = b.CodigoProduto
--where a.Id = {0}



-- update existing rows with the supplier product id
update tab
set codigo_produto_fornecedor = b.SupplierProductId
from TCAD_BASE_INVENTARIO tab
join PartnerProducts b
	on b.Supplier_Id = tab.CODIGO_FORNECEDORId
		and b.Product_Id = tab.CODIGO_PRODUTOId

-- insert new rows into inventory parameters 
insert into TCAD_BASE_INVENTARIO
select a.Supplier_Id, a.Product_Id, 1 empresa, 0 stk_min, 0 stk_max, 0 cont, 1 unid_max, 1 unid_min, a.SupplierProductId
from PartnerProducts a
Left join TCAD_BASE_INVENTARIO b
	on a.Product_Id = b.CODIGO_PRODUTOId
		and a.Supplier_Id = b.CODIGO_FORNECEDORId
where b.CODIGO_PRODUTO_FORNECEDOR is null
