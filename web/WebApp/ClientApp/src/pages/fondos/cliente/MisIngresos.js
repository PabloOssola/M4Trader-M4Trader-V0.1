import React, {useCallback} from 'react'
import Button from '@material-ui/core/Button'
import {NotificationService} from '../../../services/NotificationService';

export default function MisIngresos() {
    let onClick = useCallback(
        () => {
            NotificationService.Enviar({
                IdUsuario : 7,
                Type: "info",
                SubType: "Tranferencia",
                Message:"JGurrero realizo una transferencia",
                Date : new Date()
            })
        },
        [],
    )

    return (
        <div>
            <Button color="default" onClick={onClick}>
                    Crear Transferencia
            </Button>
        </div>
    )
}
