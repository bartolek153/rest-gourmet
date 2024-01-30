import {
  List,
  Datagrid,
  TextField,
  NumberField,
  EditButton,
  TextInput,
} from "react-admin";

const supplierFilters = [
  <TextInput source="q" label="Fornecedor" alwaysOn />,
  // <ReferenceInput source="groupId" reference="products/groups" label="Grupo">
  //   <AutocompleteInput optionText="description" label="Grupo" />
  // </ReferenceInput>,
];

const SupplierList = () => (
  <List filters={supplierFilters}>
    <Datagrid
    // rowClick="edit"
    >
      <NumberField source="id" />
      <TextField source="name" label="Nome" />
      <TextField source="company" label="Empresa" />
      <TextField source="landlinePhone" label="Telefone fixo" />
      <TextField source="mobilePhone" label="Telefone celular" />
      <TextField source="email" label="E-mail" />
      <TextField source="contact" label="Contato" />
      <TextField source="status" label="Status" />
      <EditButton />
    </Datagrid>
  </List>
);

export default SupplierList;
