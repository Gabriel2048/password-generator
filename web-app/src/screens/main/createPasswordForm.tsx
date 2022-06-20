import { FormEvent, FunctionComponent, useRef } from 'react'
import { useTimer } from './useTimer'
import { usePasswordApi } from '../../api/password/usePasswordApi';
import './form.css';

export const CreatePasswordForm: FunctionComponent = () => {
    const { start: startTimer, time } = useTimer();

    const idRef = useRef<HTMLInputElement>(null);

    const { createPassword } = usePasswordApi();

    const handleSubmit = async (e: FormEvent<HTMLFormElement>) => {
        const userId = idRef.current?.value;
        e.preventDefault();

        if (userId) {
            const res = await createPassword(userId);
            const remaining = res.expiresAt.getTime() - Date.now();
            startTimer(remaining);
        }
    };

    return (
        <div className='fill-screen'>
            <form onSubmit={handleSubmit}>
                <div>time {time}</div>
                <div>
                    <label>User Id </label>
                    <input inputMode='text' type='text' ref={idRef}></input>
                </div>
                <button type='submit'>Generate passowrd</button>
            </form>
        </div>
    )
}
