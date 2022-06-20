import { FormEvent, FunctionComponent, useRef, useState } from 'react'
import { useApi } from '../../api/useApi';
import { useTimer } from '../../hooks/useTimer';
import './createPasswordForm.css';

export const CreatePasswordForm: FunctionComponent = () => {
    const { start: startTimer, time } = useTimer(() => {
        setCreatedPassword(null);
    });
    const [createdPassword, setCreatedPassword] = useState<string | null>(null);

    const idRef = useRef<HTMLInputElement>(null);

    const { passwordApi } = useApi();

    const handleSubmit = async (e: FormEvent<HTMLFormElement>) => {
        const userId = idRef.current?.value;
        e.preventDefault();

        if (userId) {
            const apiResponse = await passwordApi.createPassword(userId);
            const remaining = apiResponse.expiresAt.getTime() - Date.now();
            setCreatedPassword(apiResponse.password);
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
                <br />
                <button type='submit'>Generate passowrd</button>
            </form>
            {createdPassword &&
                <div>
                    <h3>password: {createdPassword}</h3>
                </div>
            }
        </div>
    )
}
