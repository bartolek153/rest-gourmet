import {
  List,
  Datagrid,
  TextField,
  NumberField,
  TextInput,
  EmailField,
  EditButton,
  DateField,
} from "react-admin";

const userFilters = [
  <TextInput source="q" label="Nome" alwaysOn />,
];

const formatPhoneNumber = (phoneNumber) => {
  // accepted formats: +55 (11) 98888-8888 / 9999-9999 / 21 98888-8888 / 5511988888888
  return phoneNumber.replace(/(\d{2})(\d{2})(\d{5})(\d{4})/, "+$1 ($2) $3-$4");
}

const UserList = () => (
  <List filters={userFilters} sort={{ field: 'name', order: 'ASC' }}>
    <Datagrid rowClick="edit" >
      <NumberField source="id" />
      <TextField source="name" label="Nome" />
      <EmailField source="email" label="E-mail" />
      <DateField source="birthDate" label="Data de Nascimento" />
      <TextField source="phoneNumber" label="Núm. Celular" />
      <TextField source="cpf" label="CPF" />
      <EditButton />
    </Datagrid>
  </List>
);

export default UserList;
