import CancelIcon from '@mui/icons-material/CancelTwoTone';
import CheckIcon from '@mui/icons-material/CheckCircleTwoTone';
import {
  ArrayField,
  Datagrid,
  DateField,
  Link,
  NumberField,
  PrevNextButtons,
  Show,
  TabbedShowLayout,
  TextField,
  TopToolbar,
  useRecordContext
} from "react-admin";
import { MoneyField } from "../../components/common/MoneyField";


import { Box, Button, Divider, Stack } from "@mui/material";

const MapButton = () => {
  const receipt = useRecordContext();
  return (
    <Stack direction="row" justifyContent={"flex-start"} alignItems={"center"} spacing={1}>
      <Button variant="contained"
        component={Link}
        to={`/receipts/${receipt?.id}/mapping`}>
        Vincular
      </Button>
      <Divider orientation="vertical" flexItem variant='middle' />
      {
        receipt.inventoryProductsMapped ?
          <CheckIcon color="success" /> :
          <CancelIcon color="error" />
      }
    </Stack>
  );
};

const ReceiptShow = () => {
  return (
    <Show actions={
      <TopToolbar>
        <PrevNextButtons linkType="show" />
      </TopToolbar>
    }>
      <TabbedShowLayout>
        <TabbedShowLayout.Tab label="Informações">
          <TextField source="identification.documentNumber" label="Nota Fiscal" />
          <DateField source="identification.issueDate" label="Data de Emissão" />
          <MoneyField source="payment.netAmount" label="Valor Líquido" />
          <MoneyField source="payment.totalAmount" label="Valor Total" />

          <MapButton />

          <ArrayField source="products" label={false} >
            <Datagrid bulkActionButtons={false}>
              <TextField source="partnerProductId" label="Produto" />
              <TextField source="partnerProductDescription" label="Descrição" />
              <NumberField source="orderedQuantity" label="Qtd. Ordenada" />
              <MoneyField source="unitPrice" label="Preço Unitário" />
              <MoneyField source="totalAmount" label="Valor Total" />
              <MoneyField source="totalTaxAmount" label="Valor Impostos" />
              <MoneyField source="icmsAmount" label="Valor ICMS" />
              <MoneyField source="icmsRate" label="Alíquota ICMS" />
              <MoneyField source="ipiAmount" label="Valor IPI" />
              <MoneyField source="ipiRate" label="Alíquota IPI" />
            </Datagrid>
          </ArrayField>
        </TabbedShowLayout.Tab>
        <TabbedShowLayout.Tab label="Identificação">
          <TextField source="identification.nfeId" label="Chave NFe" />
          <TextField label="CNPJ do Emitente" source="issuer.cnpj" />
          <NumberField source="identification.serie" label="Série" />
        </TabbedShowLayout.Tab>
        {/* <TabbedShowLayout.Tab label="Produtos"></TabbedShowLayout.Tab> */}
      </TabbedShowLayout>

    </Show>
  );
};

export default ReceiptShow;
