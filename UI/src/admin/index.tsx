import { Admin, Resource, defaultLightTheme } from "react-admin";

import { dataProvider } from "../data";
import { i18nProvider } from "../i18n";
import { Route } from 'react-router-dom';

import products from "../pages/products";

import holidays from "../pages/holidays";

import inventory from "../pages/inventory";

import receipts from "../pages/receipts";
import ReceiptProductMapping from "../pages/receipts/ReceiptProductsMapping";

import employeesAttendance from "../pages/employeesAttendance";

import layoutProps from "../layout";
import suppliers from "../pages/suppliers";

import users from "../pages/users";


const App = () => (
  <Admin
    dataProvider={dataProvider}
    i18nProvider={i18nProvider}
    darkTheme={{ palette: { mode: 'dark' } }}
    theme={{ ...defaultLightTheme, palette: { mode: 'light' } }}
    {...layoutProps}
    disableTelemetry={true}
  >
    <Resource name="products" options={{ label: "Produtos" }} {...products.products} />
    <Resource name="receipts" options={{ label: "Notas Fiscais" }} {...receipts} >
      <Route path=":id/mapping" element={<ReceiptProductMapping />} />
    </Resource>
    <Resource name="inventory/parameters" options={{ label: "Parâmetros de Inventário" }} {...inventory.parameters} />
    <Resource name="employees/attendance" options={{ label: "Ponto do Funcionário" }} {...employeesAttendance} />
    <Resource name="suppliers" options={{ label: "Fornecedores" }} {...suppliers} />
    <Resource name="products/categories" options={{ label: "Categorias" }} {...products.categories} />
    <Resource name="users" options={{ label: "Usuários" }} {...users} />
    <Resource name="holidays" options={{ label: "Feriados" }} {...holidays} />
  </Admin >
);

export default App;
