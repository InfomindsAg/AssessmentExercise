import { Container } from "@mui/material";
import AppRoutes from "./routing/AppRouter";
import ShellHeader from "./routing/ShellHeader";
import CssBaseline from "@mui/material/CssBaseline";
import { BrowserRouter as Router } from "react-router-dom";

function App() {
  return (
    <>
      <CssBaseline />
      <Router basename="/app">
        <ShellHeader />
        <Container sx={{pl:1}}>
        <AppRoutes />
        </Container>
      </Router>
    </>
  );
}

export default App;
