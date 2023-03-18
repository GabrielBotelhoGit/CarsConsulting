import React, { Component, useState, useEffect } from 'react';
import CarBox from './CarBox';
import { getByBrand } from '../services/CarApiService';

const Home = () => {
  const [carsData, setCarsData] = useState([]);

  useEffect(() => {
    getByBrand("hyundai").then((response) => {
      setCarsData(response.data);
    });
  }, []);

  return (
    <div>
      <div className="TitleHomePage">
        <h2>Cars</h2>
      </div>
      <div className="CarContainer">
        {carsData.map(car => {
          return <CarBox car={car}/>
        })}
      </div>
    </div>
  );
}

export default Home;
