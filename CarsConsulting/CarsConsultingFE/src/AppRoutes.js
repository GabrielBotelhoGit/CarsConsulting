import CarFinder from "./components/CarFinder";
import Home from "./components/Home";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/CarFinder',
    element: <CarFinder />
  }
];

export default AppRoutes;
