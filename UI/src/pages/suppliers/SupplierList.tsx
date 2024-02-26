import {
  List,
  Datagrid,
  TextField,
  NumberField,
  EditButton,
  TextInput,
} from "react-admin";

const supplierFilters = [
  <TextInput source="q" label="Nome" alwaysOn />,
];

const SupplierList = () => (
  <List filters={supplierFilters}>
    <Datagrid
    // rowClick="edit"
    >
      <NumberField source="id" />
      <TextField source="name" label="Nome" />
      <TextField source="landlinePhone" label="Telefone Fixo" />
      <TextField source="mobilePhone" label="Telefone Celular" />
      <TextField source="contactEmail" label="E-mail" />
      <TextField source="contactName" label="Nome do Contato" />
      <TextField source="status" label="Status" />
      <EditButton />
    </Datagrid>
  </List>
);

export default SupplierList;
