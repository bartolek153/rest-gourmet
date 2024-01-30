import {
  List,
  Datagrid,
  TextField,
  NumberField,
  EditButton,
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
  <List filters={productFilters}>
    <Datagrid
    // rowClick="edit"
    >
      <NumberField source="id" />
      <TextField source="name" label="Nome" />
      <TextField source="startTime" label="Horário de entrada" />
      <TextField source="endTime" label="Horário de saída" />
      <TextField source="email" label="E-mail" />
      <TextField source="password" label="Senha" />
      <TextField source="status" label="Status" />
      <EditButton />
    </Datagrid>
  </List>
);

export default ProductList;
