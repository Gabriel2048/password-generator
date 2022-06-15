import { FunctionComponent } from 'react'
import { useTimer } from './useTimer'

export const Form: FunctionComponent = () => {
    const { start, time } = useTimer(5);
    return (
        <>
            <div>time {time}</div>
            <button onClick={start}>Start ticking</button>
        </>
    )
}
