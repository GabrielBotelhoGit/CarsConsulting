import React, { useState, useEffect, useCallback } from 'react';
import { library } from "@fortawesome/fontawesome-svg-core";
import { faCar, faXmark } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { confirmAlert } from 'react-confirm-alert';
import { getByBrandAndYear } from '../services/CarApiHelperService';
import { createCar } from '../services/CarsConsultingApiService';
import 'react-confirm-alert/src/react-confirm-alert.css';
import { Blocks } from 'react-loader-spinner'

library.add(faCar, faXmark);

const CarFinder = () => {
  const [loadingData, setLoadingData] = useState(true);
  const [carsData, setCarsData] = useState();
  const [carsEnumOptions, setCarsEnumOptions] = useState();

  const reloadCars = useCallback(() => {
    setLoadingData(true);
    setTimeout(() => {
      /*Promise.all([getAllCars(), getCarEnums()])
        .then((results) => {
          setCarsData(results[0].data);
          setCarsEnumOptions(results[1].data);
          setLoadingData(false);
        })*/

      getByBrandAndYear("Hyundai", 2019)
        .then((resolve) => {
          var teste = resolve.data;
        });

    }, 2000)
  }, []);

  useEffect(() => {
    if (!carsData) {
      reloadCars();
    }
  });

  return (
    <div>
      <div className="TitleHomePage">
        <h2>Find a car</h2>
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
            carsData.length > 0 && carsEnumOptions ?
              /*carsData.map(car => {
                return <CarBox car={car} key={car.id} carEnumOptions={carsEnumOptions} reloadCars={reloadCars} />
              })*/
              <p>teste</p>
              : <p>You still dont have any cars saved</p>
          )
        }
      </div>
    </div>
  );
}

export default CarFinder;
