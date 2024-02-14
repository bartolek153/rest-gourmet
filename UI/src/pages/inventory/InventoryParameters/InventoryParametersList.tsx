import {
  List,
  Datagrid,
  TextField,
  NumberField,
  TextInput,
  ReferenceInput,
  AutocompleteInput,
} from "react-admin";

const invParamsFilters = [
  <TextInput source="product" label="Produto" alwaysOn />,
  <ReferenceInput source="supplierId" reference="suppliers" label="Fornecedor">
    <AutocompleteInput optionText="name" label="Fornecedor" sx={{ width: 300 }} />
  </ReferenceInput>,
  <ReferenceInput source="productGroupId" reference="products/groups" label="Grupo de Produto">
    <AutocompleteInput optionText="description" label="Grupo de Produto" sx={{ width: 250 }} />
  </ReferenceInput>,
  <ReferenceInput source="productFamilyId" reference="products/families" label="Família de Produto">
    <AutocompleteInput optionText="description" label="Família de Produto" sx={{ width: 200 }} />
  </ReferenceInput>,
];

const InventoryParametersList = () => (
  <List filters={invParamsFilters} sort={{ field: 'product', order: 'ASC' }}>
    <Datagrid // rowClick="edit"
    >
      <TextField source="product" label="Produto" />
      <TextField source="supplier" label="Fornecedor" />
      <NumberField source="minStockQuantity" label="Qtd. Mínima" />
      <TextField source="minStockUnit" label="Unid. Qtd. Mínima" />
      <NumberField source="maxStockQuantity" label="Qtd. Máxima" />
      <TextField source="maxStockUnit" label="Unid. Qtd. Máxima" />
    </Datagrid>
  </List>
);

export default InventoryParametersList;
