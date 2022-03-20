import React from "react";
import { profileService } from "../../services/service";
import { Typography } from "@material-ui/core";
import { makeStyles } from "@material-ui/core/styles";

const styles = makeStyles({
  wrapper: {
    width: "65%",
    margin: "auto",
    textAlign: "center",
  },
  bigSpace: {
    marginTop: "5rem",
  },
  littleSpace: {
    marginTop: "2.5rem",
  },
});
const Profile = () => {
  const [data, setData] = React.useState({});
  React.useEffect(() => {
    {
      localStorage.getItem("token") &&
        profileService("3").then((response) => {
          return setData(response.data);
        });
    }
  }, []);
  const classes = styles();

  return (
    <div>
      {localStorage.getItem("token") === null ? (
        <Typography
          variant="h3"
          className={classes.littleSpace}
          color="primary"
        >
          You need to login to continue
        </Typography>
      ) : (
        <div>
          <Typography
            variant="h4"
            className={classes.littleSpace}
            color="primary"
          >
            ID: {data.id}
          </Typography>
          <Typography
            variant="h4"
            className={classes.littleSpace}
            color="primary"
          >
            NAME: {data.name}
          </Typography>
        </div>
      )}
    </div>
  );
};

export default Profile;
