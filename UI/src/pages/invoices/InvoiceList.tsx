import {
  List,
  Datagrid,
  TextField,
  NumberField,
  EditButton,
  TextInput,
  ReferenceInput,
  AutocompleteInput,
  DateInput,
  DateField,
} from "react-admin";

import { InvoiceStatusesAside } from "./InvoiceStatusesAside";

const invoiceFilters = [
  <DateInput source="issuedSince" label="Emitido Após" alwaysOn />,
  <ReferenceInput source="supplierId" reference="suppliers" label="Fornecedor">
    <AutocompleteInput optionText="name" label="Fornecedor" />
  </ReferenceInput>,
];

const InvoiceList = () => (
  <List filters={invoiceFilters} aside={<InvoiceStatusesAside />}>
    <Datagrid>
      <NumberField source="id" />
      <TextField source="supplier" label="Fornecedor" />
      <DateField label="Data de Emissão" source="issuanceDate" showTime={true} />
      <TextField source="notaFiscal" />
      <NumberField source="serie" />
      <NumberField source="totalAmount" label="Valor Original" options={{ style: "currency", currency: "BRL" }} />
      <NumberField source="netAmount" label="Valor Líquido" options={{ style: "currency", currency: "BRL" }} />
      {/* <EditButton /> */}
    </Datagrid>
  </List>
);

export default InvoiceList;
