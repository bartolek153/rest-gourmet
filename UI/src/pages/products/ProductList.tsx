import {
  List,
  Datagrid,
  TextField,
  NumberField,
  TextInput,
  ReferenceInput,
  AutocompleteInput,
} from "react-admin";

const productFilters = [
  <TextInput source="q" label="Produto" alwaysOn />,
  <ReferenceInput source="groupId" reference="products/groups" label="Grupo">
    <AutocompleteInput optionText="description" label="Grupo" />
  </ReferenceInput>,
];

const ProductList = () => (
  <List filters={productFilters} sort={{ field: 'description', order: 'ASC' }}>
    <Datagrid // rowClick="edit"
    >
      <NumberField source="id" />
      <TextField source="description" label="Descrição" />
      <TextField source="group" label="Grupo" />
      <TextField source="purchaseUnit" label="Unidade de compra" />
      <TextField source="unitMeasure" label="Unidade do produto" />
      <TextField source="status" label="Status" />
      <NumberField
        source="purchasePrice"
        label="Preço"
        options={{ style: "currency", currency: "BRL" }}
      />
      {/* <EditButton /> */}
    </Datagrid>
  </List>
);

export default ProductList;
