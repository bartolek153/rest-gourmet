import {
  List,
  Datagrid,
  TextField,
  NumberField,
  DateInput,
  BooleanField,
  DateField,
} from "react-admin";

const filters = [
  <DateInput source="from" label="De" alwaysOn />,
  <DateInput source="to" label="Até" alwaysOn />,
];

const EmployeesAttendanceList = () => (
  <List filters={filters} pagination={false}>
    <Datagrid
    // rowClick="edit"
    >
      <NumberField source="id" />
      <TextField source="name" label="Nome" />
      <DateField source="timeIn" label="Horário de entrada" />
      <DateField source="timeOut" label="Horário de saída" />
      <BooleanField source="worksSaturdays" label="Trabalha de Sáb." />
      <TextField source="absences" label="Ausências" />
      <TextField source="lateArrivalCount" label="Atrasos (dias)" />
      <TextField source="lateMinutes" label="Atrasos (minutos)" />
      <TextField source="overtimeMinutes" label="Extra" />
      <TextField source="balanceMinutes" label="Saldo" />
    </Datagrid>
  </List>
);

export default EmployeesAttendanceList;
