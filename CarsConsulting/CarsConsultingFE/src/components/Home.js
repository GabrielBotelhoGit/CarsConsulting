import React, { useState, useEffect, useCallback } from 'react';
import CarBox from './CarBox';
import { getAllCars, getCarEnums } from '../services/CarsConsultingApiService';
import { Blocks } from 'react-loader-spinner'
import { Link } from 'react-router-dom';
import { NavLink } from 'reactstrap';

const Home = () => {
  const [loadingData, setLoadingData] = useState(true);
  const [carsData, setCarsData] = useState();
  const [carsEnumOptions, setCarsEnumOptions] = useState();

  const reloadCars = useCallback(() => {
    setLoadingData(true);
    setTimeout(() => {
      Promise.all([getAllCars(), getCarEnums()])
        .then((results) => {
          setCarsData(results[0].data);
          setCarsEnumOptions(results[1].data);
          setLoadingData(false);
        })
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
        <h2>Saved Cars</h2>
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
            carsData.map(car => {
              return <CarBox car={car} key={car.id} carEnumOptions={carsEnumOptions} reloadCars={reloadCars} />
            })
              : <p>You still dont have any cars saved.  <NavLink tag={Link} className="linkHere" to="/CarFinder">Try our car finder function here</NavLink></p>
            )
        }
      </div>
    </div>
  );
}

export default Home;
