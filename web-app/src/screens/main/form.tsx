import { FunctionComponent, useCallback, useRef } from 'react'
import { useTimer } from './useTimer'
import './form.css';

export const Form: FunctionComponent = () => {
    const { start: startTimer, time } = useTimer(5);

    const passwordRef = useRef<HTMLInputElement>(null);
    const idRef = useRef<HTMLInputElement>(null);

    const handleSubmit = useCallback(() => {
        const userId = idRef.current?.value;
        const password = passwordRef.current?.value;

        if (userId && password) {
            // todo
        }
    }, []);


    return (
        <div className='fill-screen'>
            <form onSubmit={handleSubmit}>
                <div>time {time}</div>
                <div>
                    <label>User Id </label>
                    <input inputMode='text' type='text' ref={idRef}></input>
                </div>
                <div>
                    <label>Password </label>
                    <input inputMode='text' type='password' ref={passwordRef}></input>
                </div>
                <button type='submit' onClick={startTimer}>Generate passowrd</button>
            </form>
        </div>
    )
}
