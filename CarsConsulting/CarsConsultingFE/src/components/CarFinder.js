import React, { useState, useEffect, useCallback } from 'react';
import { useNavigate } from 'react-router-dom';
import { library } from "@fortawesome/fontawesome-svg-core";
import { faMagnifyingGlass } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { getByBrandAndYear } from '../services/CarApiHelperService';
import 'react-confirm-alert/src/react-confirm-alert.css';
import { Blocks } from 'react-loader-spinner'
import CarFindingsBox from './CarFindingsBox';

library.add(faMagnifyingGlass);

const CarFinder = () => {
  const [loadingData, setLoadingData] = useState(true);
  const [carsData, setCarsData] = useState();
  const [maker, setMaker] = useState("");
  const [year, setYears] = useState("");
  const navigate = useNavigate();

  function getBase64(file) {
    var reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = function () {
      console.log(reader.result);
    };
    reader.onerror = function (error) {
      console.log('Error: ', error);
    };
  }

  const updateMaker = (event) => {
    setMaker(event.target.value);
  };

  const updateYear = (event) => {
    setYears(event.target.value);
  };

  const reloadCars = useCallback((firstRun) => {
    if (firstRun) {
      setMaker("Hyundai");
      setYears("2019");
    }
    setLoadingData(true);
    if (maker && year) {
      getByBrandAndYear(maker, year)
        .then((resolve) => {
          setCarsData(resolve.data);
          setLoadingData(false);
        });
    }    

  }, [maker, year]);

  useEffect(() => {
    if (!carsData) {
      reloadCars(true);
    }
  });

  return (
    <div>
      <div className="TitleCarFinderPage">
        <h2>Find a car</h2>
        <div className="CarFinderSearch">
          <div className="CarFinderFields">
            <span>Maker</span>
            <input type="text" value={maker} onChange={updateMaker} />
          </div>
          <div className="CarFinderFields">
            <span>Year</span>
            <input type="text" value={year} onChange={updateYear} />
          </div>
          <button type="button" className="searchButton" onClick={() => reloadCars(false)}><FontAwesomeIcon icon="fa-solid fa-magnifying-glass" /></button>
        </div>        
      </div>
      <div className="CarContainer">
        {loadingData ?
          <Blocks
            visible={true}
            height="80"
            width="80"
            ariaLabel="blocks-loading"
            wrapperStyle={{}}
            wrapperClass="blocks-wrapper"
          />
          : (
            carsData.length > 0 ?
              carsData.map(car => {
                return <CarFindingsBox car={car} key={car.id} navigate={navigate} />
              })
              : <p>Your search was unsuccessful</p>
          )
        }
      </div>
    </div>
  );
}

export default CarFinder;
