import React, { useMemo, CSSProperties } from "react";
import { useGetList } from "react-admin";

import { PieChart } from "@mui/x-charts/PieChart";

import { useMediaQuery, Theme } from "@mui/material";
import { subDays, startOfDay } from "date-fns";
import CardWithIcon from "./CardWithIcon";

import DollarIcon from "@mui/icons-material/AttachMoney";

import { Box, Typography } from "@mui/material";

// interface AttendanceStats {
//   total: number;
//   present: number;
//   absent: number;
//   late: number;
//   onTime: number;
//   absentStudents: Student[];
//   lateStudents: Student[];
// }

// interface InventoryStats {
//   total: number;
//   available: number;
//   unavailable: number;
//   lowStock: number;
//   outOfStock: number;
//   lowStockItems: Item[];
//   outOfStockItems: Item[];
// }

// interface ActivitiesStats {
//   total: number;
//   activities: Activity[];
//   pending: number;
// }

// interface InvoiceStats {
//   total: number;
//   pending: number;
// }

// interface DashboardStats {
//   revenue: number;
//   nbNewOrders: number;
//   pendingOrders: Order[];
// }

const styles = {
  flex: { display: "flex" },
  flexColumn: { display: "flex", flexDirection: "column" },
  leftCol: { flex: 1, marginRight: "0.5em" },
  rightCol: { flex: 1, marginLeft: "0.5em" },
  singleCol: { marginTop: "1em", marginBottom: "1em" },
};

const Spacer = () => <span style={{ width: "1em" }} />;
const VerticalSpacer = () => <span style={{ height: "1em" }} />;

const Dashboard = () => {
  const isXSmall = useMediaQuery((theme: Theme) =>
    theme.breakpoints.down("sm")
  );
  const isSmall = useMediaQuery((theme: Theme) => theme.breakpoints.down("lg"));
  const aMonthAgo = useMemo(() => subDays(startOfDay(new Date()), 30), []);

  // const { data: orders } = useGetList<Order>("commands", {
  //   filter: { date_gte: aMonthAgo.toISOString() },
  //   sort: { field: "date", order: "DESC" },
  //   pagination: { page: 1, perPage: 50 },
  // });

  // const aggregation = useMemo<State>(() => {
  //   if (!orders) return {};
  //   const aggregations = orders
  //     .filter((order) => order.status !== "cancelled")
  //     .reduce(
  //       (stats: OrderStats, order) => {
  //         if (order.status !== "cancelled") {
  //           stats.revenue += order.total;
  //           stats.nbNewOrders++;
  //         }
  //         if (order.status === "ordered") {
  //           stats.pendingOrders.push(order);
  //         }
  //         return stats;
  //       },
  //       {
  //         revenue: 0,
  //         nbNewOrders: 0,
  //         pendingOrders: [],
  //       }
  //     );
  //   return {
  //     recentOrders: orders,
  //     revenue: aggregations.revenue.toLocaleString(undefined, {
  //       style: "currency",
  //       currency: "USD",
  //       minimumFractionDigits: 0,
  //       maximumFractionDigits: 0,
  //     }),
  //     nbNewOrders: aggregations.nbNewOrders,
  //     pendingOrders: aggregations.pendingOrders,
  //   };
  // }, [orders]);

  // const { nbNcewOrders, pendingOrders, revenue, recentOrders } = aggregation;
  return isXSmall ? (
    <div></div>
  ) : isSmall ? (
    <div>
      <Typography variant="h6" gutterBottom>
        Aquisição
      </Typography>
    </div>
  ) : (
    // <div style={styles.flexColumn as CSSProperties}>
    //   <div style={styles.singleCol}></div>
    //   <div style={styles.flex}>
    //     <MonthlyRevenue value={revenue} />
    //     <Spacer />
    //     <NbNewOrders value={nbNewOrders} />
    //   </div>
    //   <div style={styles.singleCol}>
    //     <OrderChart orders={recentOrders} />
    //   </div>
    //   <div style={styles.singleCol}>
    //     <PendingOrders orders={pendingOrders} />
    //   </div>
    // </div>

    <>
      <div style={styles.flex}>
        <div style={styles.leftCol}>
          <div style={styles.flex}>
            <CardWithIcon
              to="/commands"
              icon={DollarIcon}
              title="Teste"
              subtitle={"123"}
            />
            <Spacer />
            <PieChart
              series={[
                {
                  data: [
                    { id: 0, value: 10, label: "series A" },
                    { id: 1, value: 15, label: "series B" },
                    { id: 2, value: 20, label: "series C" },
                  ],

                  innerRadius: 30,
                  outerRadius: 100,
                  paddingAngle: 5,
                  cornerRadius: 5,
                  startAngle: -90,
                  endAngle: 180,
                  cx: 150,
                  cy: 150,
                },
              ]}
            />
          </div>
          <div style={styles.singleCol}>
            {/* <OrderChart orders={recentOrders} /> */}
          </div>
          <div style={styles.singleCol}>
            <CardWithIcon
              to="/commands"
              icon={DollarIcon}
              title="Teste"
              subtitle={"123"}
            />
          </div>
        </div>
        <div style={styles.rightCol}>
          <div style={styles.flex}>
            <CardWithIcon
              to="/commands"
              icon={DollarIcon}
              title="Teste"
              subtitle={"123"}
            />
            <Spacer />
            <CardWithIcon
              to="/commands"
              icon={DollarIcon}
              title="Teste"
              subtitle={"123"}
            />
          </div>
        </div>
      </div>
    </>
  );
};

export default Dashboard;
