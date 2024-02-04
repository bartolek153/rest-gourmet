import { Admin, Resource } from "react-admin";

import { dataProvider } from "../data";
import { i18nProvider } from "../i18n";

import products from "../pages/products";
import suppliers from "../pages/suppliers";
import employees from "../pages/employees";
import invoices from "../pages/invoices";

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
  </Admin>
);

export default App;
