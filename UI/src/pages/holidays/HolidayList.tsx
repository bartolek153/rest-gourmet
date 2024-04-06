import {
  List,
  Datagrid,
  TextField,
  NumberField,
  DateField,
} from "react-admin";

const HolidayList = () => (
  <List sort={{ field: 'name', order: 'ASC' }}>
    <Datagrid>
      <NumberField source="id" />
      <TextField source="description" label="Descrição" />
      <DateField source="date" label="Data" />
    </Datagrid>
  </List>
);

export default HolidayList;
