import {
  Datagrid,
  TextField,
  NumberField,
  ReferenceInput,
  AutocompleteInput,
  DateInput,
  DateField,
  InfiniteList,
  Count,
  useStore,
  FilterList,
  FilterListItem,
  Filter,
} from "react-admin";
import InventoryIcon from '@mui/icons-material/Inventory';
import { Box, Card, CardContent } from '@mui/material';

const ReceiptStatusesAside = () => {
  return (
    <Box width={200} mr={1} mt={7} flexShrink={0} order={-1}>
      <Card>
        <CardContent>
          <Filter>
            <DateInput source="issuedSince" label="Emitido Após" alwaysOn />
          </Filter>
          <FilterList label="Mapeamento" icon={<InventoryIcon />}>
            <FilterListItem label="Todos" value={{ unmappedOnly: false }} />
            <FilterListItem label="Pendentes" value={{ unmappedOnly: true }} />
          </FilterList>
        </CardContent>
      </Card>
    </Box>
  );
};

const receiptFilters = [
  <ReferenceInput source="supplierId" reference="suppliers" label="Fornecedor" alwaysOn>
    <AutocompleteInput optionText="name" label="Fornecedor" sx={{ width: 300 }} />
  </ReferenceInput>,
];

const ReceiptList = () => (
  <InfiniteList filters={receiptFilters} aside={<ReceiptStatusesAside />}>
    <Datagrid rowClick="show">
      <NumberField source="id" />
      <TextField source="supplier" label="Fornecedor" />
      <DateField source="issueDate" label="Data de Emissão" showTime={true} />
      <TextField source="documentNumber" label="Nota Fiscal" />
      <NumberField source="serie" label="Série" />
      <NumberField source="totalAmount" label="Valor Original" options={{ style: "currency", currency: "BRL" }} />
      <NumberField source="netAmount" label="Valor Líquido" options={{ style: "currency", currency: "BRL" }} />
    </Datagrid>
  </InfiniteList>
);

export default ReceiptList;
