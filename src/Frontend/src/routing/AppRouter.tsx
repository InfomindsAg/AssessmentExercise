import { Routes, Route } from "react-router-dom";
import HomePage from "../pages/HomePage";
import CustomerListPage from "../pages/CustomerListPage";
import EmployeeListPage from "../pages/EmployeeListPage";
import SupplierListPage from "../pages/SupplierListPage";

export default function AppRoutes() {
  return (
    <Routes>
      <Route path="/" element={<HomePage />} />
      <Route path="/SupplierList" element={<SupplierListPage />} />
      <Route path="/CustomerList" element={<CustomerListPage />} />
      <Route path="/EmployeeList" element={<EmployeeListPage />} />
      
    </Routes>
  );
}
