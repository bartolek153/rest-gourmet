import { Admin, Resource } from "react-admin";

import { dataProvider } from "../data";
import { i18nProvider } from "../i18n";
import { Route } from 'react-router-dom';

import products from "../pages/products";

import inventory from "../pages/inventory";

import receipts from "../pages/receipts";
import ReceiptProductMapping from "../pages/receipts/ReceiptProductsMapping";

import layoutProps from "../layout";

// icons
// - products: grocery
// - inventory: shelf
// - suppliers: truck
// - employees: Assignment Ind
// - attendance: schedule
// - company: store

// const lightTheme = defaultTheme;
// const darkTheme = { ...defaultTheme, palette: { mode: 'dark' } };

const App = () => (
  <Admin
    dataProvider={dataProvider}
    i18nProvider={i18nProvider}
    // theme={lightTheme}
    // darkTheme={darkTheme}
    {...layoutProps}
    disableTelemetry={true}
  >
    <Resource name="products" options={{ label: "Produtos" }} {...products} />
    <Resource name="receipts" options={{ label: "Notas Fiscais" }} {...receipts} >
      <Route path=":id/mapping" element={<ReceiptProductMapping />} />
    </Resource>
    <Resource name="inventory/parameters" options={{ label: "Parâmetros de Inventário" }} {...inventory.parameters} />
  </Admin>
);

export default App;
