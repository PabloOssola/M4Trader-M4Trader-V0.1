import React, { Fragment, useState } from 'react';
import NumberFormat from 'react-number-format';


function NumberFormatCustom(props) {
    const { inputRef, onChange, ...other } = props;

    return (
        <NumberFormat
            {...other}
            getInputRef={inputRef}
            onValueChange={(values) => {
                onChange({
                    target: {
                        name: props.name,
                        value: values.value,
                    },
                });
            }}
            thousandSeparator
            isNumericString
        // prefix={prefix}
        />
    );
}


export default NumberFormatCustom;