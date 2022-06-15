import { FunctionComponent } from 'react'
import { useTimer } from './useTimer'

export const Form: FunctionComponent = () => {
    const { start: startTimer, time } = useTimer(5);
    return (
        <>
            <div>time {time}</div>
            <button onClick={startTimer}>Start ticking</button>
        </>
    )
}
