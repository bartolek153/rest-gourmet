import {
  ArrayField,
  BooleanField,
  Datagrid,
  DateField,
  NumberField,
  PrevNextButtons,
  Show,
  SimpleShowLayout,
  TextField,
  TopToolbar,
  ExportButton
} from "react-admin";
import { downloadXLSX } from "../../utils";


const exporter = rows => {
  const rowsForExport = rows.map(row => {
    const { worksSaturdays, ...data } = row;  // perform transformation
    data.worksSaturdays = worksSaturdays ? 'Sim' : 'Não';
    return data;
  });
  const headers = [
    [
      'Data',
      'Entrada',
      'Saída',
      'Atrasos (minutos)',
      'Extra (minutos)',
      'Motivo Ocorrência'
    ]
  ];
  downloadXLSX(rowsForExport, headers, `ponto-detalhe`);
};

const rowStyle = (record, index) => {
  if (record.incidentReason) return { backgroundColor: "#FFC7C7" };
  if (record.lateMinutes === 0) return { backgroundColor: "#B8FFD9" };
  if (record.LateMinutes <= 5) return { backgroundColor: "#FFF9C7" };
  return { backgroundColor: "#FFC7C7" };
};

const EmployeeAttendanceShow = () => {
  return (
    <Show
      actions={
        <TopToolbar>
          <PrevNextButtons linkType="show" />
        </TopToolbar>
      }
    >
      <SimpleShowLayout>
        <TextField source="employeeInfo.name" label="Nome" />
        <TextField source="employeeInfo.startTime" label="Entrada" />
        <TextField source="employeeInfo.endTime" label="Saída" />
        <NumberField source="employeeInfo.maxOvertimeHoursAllowed" label="Máx. Horas Extras" />
        <BooleanField source="employeeInfo.worksSaturdays" label="Trabalha de Sáb." />
        {/* <ExportButton exporter={exporter} id={id} /> */}

        <ArrayField source="workingDays" label="Registros" >
          <Datagrid bulkActionButtons={false} rowSx={rowStyle}>
            <DateField source="date" label="Data" />
            <TextField source="timeIn" label="Entrada" />
            <TextField source="timeOut" label="Saída" />
            <NumberField source="lateMinutes" label="Atrasos (minutos)" />
            <NumberField source="overtimeMinutes" label="Extra (minutos)" />
            <TextField source="incidentReason" label="Motivo Ocorrência" />
          </Datagrid>
        </ArrayField>
      </SimpleShowLayout>
    </Show>
  );
};

export default EmployeeAttendanceShow;
