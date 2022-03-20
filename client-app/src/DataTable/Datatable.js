import React, { useEffect, useState } from "react";
import axios from "axios";
import { DataGrid } from "@mui/x-data-grid";
import { makeStyles } from "@material-ui/core/styles";
import Button from "@mui/material/Button";
import { Link } from "react-router-dom";
import TextField from "@mui/material/TextField";

const styles = makeStyles({
  table: {
    boxShadow: "2px 2px 5px -1px rgba(0,0,0,0.75)",
    width: "cover",
    margin: "25px 100px 0 100px",
  },
});
const Datatable = () => {
  const [gridData, setGridData] = useState([]);
  const [loading, setLoading] = useState(false);
  const [searchText, setSearchText] = useState("");
  let [filteredData] = useState();

  useEffect(() => {
    loadData();
  }, []);

  const loadData = async () => {
    setLoading(true);
    const response = await axios.get(
      "https://localhost:7141/api/book/Book"
    );
    setGridData(response.data);
    setLoading(false);
  };

  const modifiedData = gridData.map(({ ...item }) => ({
    ...item,
    key: item.id,
  }));

  const handleDelete = (value) => {
    const dataSource = [...modifiedData];
    const filteredData = dataSource.filter((item) => item.id !== value.id);
    setGridData(filteredData);
  };
  const classes = styles();
  const columns = [
    {
      headerName: "ID",
      field: "id",
      width: 100,
      disableColumnMenu: true,
    },
    {
      headerName: "Title",
      field: "title",
      width: 500,
    },
    {
      headerName: "Body",
      field: "body",
      width: 500,
    },
    {
      headerName: "Actions",
      field: "actions",
      width: 220,
      sortable: false,
      disableColumnMenu: true,
      renderCell: (item) =>
        modifiedData.length >= 1 ? (
          <div>
            <Button
              size="small"
              variant="contained"
              color="error"
              onClick={() => handleDelete(item)}
            >
              Delete
            </Button>

            <Link
              style={{ marginLeft: "2.5em", textDecoration: "none" }}
              to={`/posts/${item.id}`}
            >
              <Button size="small" variant="contained">
                Detail
              </Button>
            </Link>
          </div>
        ) : null,
    },
  ];

  const handleSearch = (e) => {
    setSearchText(e.target.value);
    if (e.target.value === "") {
      loadData();
    }
  };
  const globalSearch = () => {
    filteredData = modifiedData.filter((value) => {
      return (
        value.title.toLowerCase().includes(searchText.toLowerCase()) ||
        value.body.toLowerCase().includes(searchText.toLowerCase())
      );
    });
    setGridData(filteredData);
  };
  return (
    <div>
      <div>
        <TextField
          id="outlined-basic"
          label="Search for Title & Body"
          variant="outlined"
          onChange={handleSearch}
          value={searchText}
          size="small"
        />
        <Button style={{ marginLeft: "2.5em", backgroundColor: "#4f25f7"}} variant="contained" onClick={globalSearch}>
          Search
        </Button>
      </div>
      <div className={classes.table}>
        <DataGrid
          autoHeight
          {...modifiedData}
          columns={columns}
          rows={
            filteredData && filteredData.length ? filteredData : modifiedData
          }
          pageSize={5}
          rowsPerPageOptions={[5]}
          loading={loading}
        />
      </div>
    </div>
  );
};

export default Datatable;
