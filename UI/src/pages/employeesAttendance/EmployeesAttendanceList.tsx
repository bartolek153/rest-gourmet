import {
  List,
  Datagrid,
  TextField,
  NumberField,
  DateInput,
  BooleanField,
  required,
} from "react-admin";
import { downloadXLSX } from "../../utils";

const curDate = new Date();

const filters = [
  <DateInput source="from" label="De" alwaysOn validate={required()} />,
  <DateInput source="to" label="Até" alwaysOn validate={required()} />
];

const exporter = rows => {
  const rowsForExport = rows.map(row => {
    const { worksSaturdays, ...data } = row;  // perform transformation
    data.worksSaturdays = worksSaturdays ? 'Sim' : 'Não';
    return data;
  });
  const headers = [
    [
      'ID',
      'Nome',
      'Entrada',
      'Saída',
      'Dias trabalhados',
      'Ocorrências',
      'Dias obrigatórios',
      'Ausências',
      'Atrasos (dias)',
      'Atrasos (minutos)',
      'Extra (minutos)',
      'Trabalha de Sáb.'
    ]
  ];
  downloadXLSX(rowsForExport, headers, `ponto-${curDate.getFullYear()}-${curDate.getMonth() + 1}`);
};


const EmployeesAttendanceList = () => (
  <List
    filters={filters}
    pagination={false}
    storeKey={false}
    exporter={exporter}
    filterDefaultValues={{
      from: new Date(curDate.getFullYear(), curDate.getMonth(), 1).toISOString(),
      to: curDate.toISOString()
    }}
  >
    <Datagrid bulkActionButtons={false} rowClick="show">
      <TextField source="name" label="Nome" />
      <TextField source="timeIn" label="Hor. Entrada" />
      <TextField source="timeOut" label="Hor. Saída" />
      <BooleanField source="worksSaturdays" label="Trabalha de Sáb." />
      <NumberField source="workedDays" label="Dias trabalhados" />
      <NumberField source="incidentDays" label="Ocorrências" />
      <NumberField source="mandatedWorkDays" label="Dias obrigatórios" />
      <NumberField source="absenceDays" label="Ausências" />
      <TextField source="lateArrivalCount" label="Atrasos (dias)" />
      <TextField source="lateMinutes" label="Atrasos (minutos)" />
      <TextField source="overtimeMinutes" label="Extra (minutos)" />
    </Datagrid>
  </List>
);

export default EmployeesAttendanceList;
