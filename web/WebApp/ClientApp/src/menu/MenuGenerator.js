import React from "react";
import structure from './menuAdmin';


function menuGenerator(item) {

   
    let icon = structure[item.name];
  
    let travel = {
      id: item.key,
      key: item.key,
      label: item.title,
      link: item.url,
      icon: icon

    };


  if (item.items.length > 0) {
    travel.children = item.items.map(ite => {

      return {
        id: `${item.key}_${ite.key}`,
        key: `${item.key}_${ite.key}`,
        label: ite.title,
        link: ite.url
      }

    });

  }

  return travel;

}
export {
  menuGenerator,
  structure
}