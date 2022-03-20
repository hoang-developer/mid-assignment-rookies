import React, {useEffect, useState} from 'react'
import { useParams } from "react-router-dom";
import { Typography } from "@material-ui/core";
import {makeStyles} from "@material-ui/core/styles"; 

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
    }
  });
export default function PostDetail({row}) {
  const { id } = useParams();
    useEffect(() => {
        fetchItem();
        console.log(row);
    }, []);

    const [item, setItem] = useState({})

    const fetchItem = async() => {
        const fetchItem = await fetch(`https://jsonplaceholder.typicode.com/posts/${id}`);
        const item = await fetchItem.json();
        setItem(item)
    }
    const classes = styles();
  return (
    <div>
        <div className={classes.wrapper}>
        <Typography variant="h2" className={classes.bigSpace} color="primary">ID: {item.id}</Typography>
        <Typography variant="h4" className={classes.littleSpace} color="primary">TITLE: {item.title}</Typography>
        <Typography variant="h6" className={classes.littleSpace} color="primary">BODY: {item.body}</Typography>
        </div>
    </div>
  )
}
