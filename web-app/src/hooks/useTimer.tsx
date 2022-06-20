import { useEffect, useState } from "react";

const oneSecond = 1000;

export type OnTimerExpiredCallback = () => void;

export const useTimer = (onTimerExpired?: OnTimerExpiredCallback) => {
    const [time, setTime] = useState<number>(0);
    const [intervalId, setIntervalId] = useState<NodeJS.Timer>();
    useEffect(() => {
        if (time === 0) {
            onTimerExpired?.();
            clearInterval(intervalId);
        }
    }, [time, intervalId, onTimerExpired]);

    const resetTimerIfStarted = (seconds: number) => {
        if (intervalId != null) {
            clearInterval(intervalId);
        }
        setTime(seconds);
    };

    const secondTick = () => {
        setTime(time => time - 1);
    };

    const start = (millisecons: number) => {
        const seconds = roundMilliseconsToSeconds(millisecons);
        resetTimerIfStarted(seconds);

        const interval = setInterval(secondTick, oneSecond);
        setIntervalId(interval);
    };

    return {
        start,
        time
    };
};

const roundMilliseconsToSeconds = (milliseconds: number) => {
    return Math.floor(milliseconds / oneSecond);
};