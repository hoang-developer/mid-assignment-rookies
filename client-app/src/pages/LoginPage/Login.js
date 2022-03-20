import React from "react";
import { makeStyles } from "@material-ui/core/styles";
import {useFormik} from "formik"
import * as Yup from "yup"
import { loginService, profileService } from "../../services/service";

const styles = makeStyles({
  form: {
    backgroundColor: "#4f25f7",
    padding: "50px",
    borderRadius: "10px",
    display: "flex",
    flexDirection: "column",
    alignItems: "center",
    boxShadow: "5px 5px 15px -1px rgba(0,0,0,0.75)",
    color: "white",
  },
  formContainer: {
    height: "50vh",
    padding: "20px",
    display: "flex",
    flexDirection: "column",
    justifyContent: "center",
    alignItems: "center",
  },
  formInput: {
    width: "100%",
    margin: "10px",
    height: "40px",
    borderRadius: "5px",
    border: "1px solid gray",
    padding: "5px",
    fontFamily: "'Roboto', sans-serif",
  },
  formSubmit: {
    width: "50%",
    padding: "10px",
    borderRadius: "5px",
    color: "#4f25f7",
    backgroundColor: "#fff",
    border: "none",
    cursor: "pointer",
  },
  formMarketing: {
    display: "flex",
    margin: "20px",
    alignItems: "center",
  },
  validationText: {
    margin: "0px",
    fontSize: "0.7em"
  },
  validContainer: {
    height: "20px"
  }
});


const Login = () => {
  const formik = useFormik({
    initialValues:{
      email: "",
      password: "",
      rememberCheck: true,
    },
    validationSchema: Yup.object({
        email: Yup.string()
        .email("Invalid email address !").required("Required !"),
        password: Yup.string()
        .min(8, "Must be at least 8 characters !").required("Required !")
    }),
    onSubmit: () => { 
      console.log("OK")
        loginService().then((response)=>{
          localStorage.setItem("token", response.data.token)
          localStorage.setItem("userID", response.data.userId)
          window.location.reload()
        })
    }
});


  
  const classes = styles();

  return (
    <div className={classes.formContainer}>
      <form className={classes.form} onSubmit={formik.handleSubmit}>
        <input
          type="email"
          placeholder="Email address"
          className={classes.formInput}
          name="email"
          onChange={formik.handleChange}
          onBlur={formik.handleBlur}
          value={formik.values.email}
        />

        <div className={classes.validContainer}>
        {formik.touched.email && formik.errors.email ? <p className={classes.validationText}>{formik.errors.email}</p> : null}
        </div>

        <input
          type="password"
          placeholder="Password"
          className={classes.formInput}
          name="password"
          onChange={formik.handleChange}
          onBlur={formik.handleBlur}
          value={formik.values.password}
        />

        <div className={classes.validContainer}>
        {formik.touched.password && formik.errors.password ? <p className={classes.validationText}>{formik.errors.password}</p> : null}
        </div>

        <div className={classes.formMarketing}>
          <input
            id="okayToRemember"
            type="checkbox"
            name="rememberCheck"
            onChange={formik.handleChange}
            value={formik.values.rememberCheck}
          />
          <label htmlFor="okayToRemember">Remember me</label>
        </div>
        <button type="submit" className={classes.formSubmit}>Login</button>
      </form>
    </div>
  );
};

export default Login;
