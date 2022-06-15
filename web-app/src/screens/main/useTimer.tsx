import { useEffect, useState } from "react";

const oneSecond = 1000;
export const useTimer = (initialTime: number) => {
    const [time, setTime] = useState<number>(initialTime);
    const [intervalId, setIntervalId] = useState<NodeJS.Timer>();
    useEffect(() => {
        if (time === 0) {
            clearInterval(intervalId);
        }
    }, [time, intervalId]);

    const resetTimerIfStarted = () => {
        if (intervalId != null) {
            setTime(initialTime);
            clearInterval(intervalId);
        }
    }

    const secondTick = () => {
        setTime(time => time - 1);
    };

    const start = () => {
        resetTimerIfStarted();

        const interval = setInterval(secondTick, oneSecond);
        setIntervalId(interval);
    };

    return {
        start,
        time
    };
};