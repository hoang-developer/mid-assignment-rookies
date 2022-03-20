import React from 'react';
import {
  createTheme,
  ThemeProvider,
} from "@material-ui/core/styles";
import { Routes, Route } from "react-router-dom";
import NavBar from "./components/NavBar.js";
import "./App.css";
import Footer from "./components/Footer";
import HomePage from "./pages/Home"
import PostsPage from "./pages/PostsPage/Posts"
import ProfilePage from "./pages/ProfilePage/Profile"
import LoginPage from "./pages/LoginPage/Login"
import PostDetail from "./pages/PostsPage/PostDetail.js";



const theme = createTheme({
  palette: {
    primary: {
      main: "#2e1667",
    },
    secondary: {
      main: "#c7d8ed",
    },
  },
  typography: {
    fontFamily: ["Roboto"],
    h4: {
      fontWeight: 600,
      fontSize: 28,
      lineHeight: "2rem",
    },
    h5: {
      fontWeight: 100,
      lineHeight: "2rem",
    },
  },
});

function App() {
  return (
    <div className="App">
      <ThemeProvider theme={theme}>
        <NavBar />
        <Routes>
        <Route exact path = "/" element={<HomePage/>} />
        <Route path = "/posts" exact element={<PostsPage/>} />
        <Route path = "/posts/:id" element={<PostDetail/>} />
        <Route path = "/profile" element={<ProfilePage/>}/>
        <Route path = "/login" element={<LoginPage/>} />
      </Routes>
        <div >
          <Footer />
        </div>
      </ThemeProvider>
      
    </div>
  );
}

export default App;
