import React from 'react';
import { library } from "@fortawesome/fontawesome-svg-core";
import { faCar } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';

library.add(faCar);

const CarBox = ({ car }) => {
  return (
    <div className="CarBox">
      <FontAwesomeIcon icon="fa-solid fa-car" />
      <div className="infoLine">
        <span>
          Model:
        </span>
        <span>
          {car.model}
        </span>
      </div> 
      <div className="infoLine">
        <span>
          Motor type:
        </span>
        <span>
          {car.fuel_type}
        </span>
      </div>           
      <div className="infoLine">
        <span>
          Transmission:
        </span>
        <span>
          {car.transmission}
        </span>
      </div>   
      <div className="infoLine">
        <span>
          Brand:
        </span>
        <span>
          {car.make}
        </span>
      </div> 
    </div>
  );
}

export default CarBox;
