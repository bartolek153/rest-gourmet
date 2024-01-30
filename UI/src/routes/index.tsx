import { Route } from "react-router-dom";
import LessonEditPage from "./LessonEditPage";

export default [
  <Route
    exact
    path="/course-plan/:plan_id/plan-lesson/:id"
    component={LessonEditPage}
  />,
];
