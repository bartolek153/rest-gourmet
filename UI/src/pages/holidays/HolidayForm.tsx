import { Create, DateInput, Edit, SimpleForm, TextInput } from "react-admin";

const HolidayForm = () => {
  return (
    <SimpleForm>
      <TextInput source="description" label="Descrição" isRequired fullWidth />
      <DateInput source="date" label="Data" isRequired />
    </SimpleForm>
  );
};

export const HolidayEdit = (props: any) => (
  <Edit {...props} mutationMode="pessimistic">
    <HolidayForm />
  </Edit>
);

export const HolidayCreate = (props: any) => (
  <Create {...props}>
    <HolidayForm />
  </Create>
);
