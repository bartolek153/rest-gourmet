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
    disableTelemetry={true}
  >
    <Resource name="products" options={{ label: "Produtos" }} {...products} />
    {/* <Resource
      name="employees"
      options={{ label: "Funcionários" }}
      {...employees}
    />
    <Resource
      name="suppliers"
      options={{ label: "Fornecedores" }}
      {...suppliers}
    /> */}
    <Resource name="invoices" options={{ label: "Notas Fiscais" }} {...invoices} />
  </Admin>
);

export default App;
